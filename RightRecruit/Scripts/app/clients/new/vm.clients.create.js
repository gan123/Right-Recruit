define('vm.clients.create',
    ['jquery', 'amplify', 'ko', 'config', 'dataservice.lookups', 'dataservice.client', 'dataservice.search', 'model.industry', 'model.client', 'model.country', 'model.state', 'model.city'],
    function ($, amplify, ko, config, lookups, clientService, clientSearchService, industryModel, clientModel, countryModel, stateModel, cityModel) {
        var
            logger = config.logger,
            client = ko.observable(new clientModel()),
            industries = ko.observableArray(),
            countries = ko.observableArray(),
            allStates = ko.observableArray(),
            states = ko.observableArray([]),
            allCities = ko.observableArray(),
            cities = ko.observableArray([]),
            priorities = ko.observableArray([]),
            validationErrors = ko.observableArray(),
            existingClientNames = ko.observableArray([]),
            isValid = ko.computed(function() {
                return validationErrors().length === 0 && client().AddressValidationErrors().length === 0
                    && client().PhoneValidationErrors().length === 0;
            }),
            createCommand = ko.asyncCommand({
                execute: function (complete) {
                    clientService.create(client(), {
                        success: function (response) {
                            logger.success(config.toasts.savedData);
                            complete();
                        },
                        error: function (response) {
                            
                        }
                    });
                },
                canexecute: function(isExecuting) {
                    console.log(isValid);
                    return !isExecuting && isValid;
                }
            }),
            contactsTemplate = 'client.contacts.list';

        client().Address().Country.subscribe(function(val) {
            states([]);
            $.each(allStates(), function(i, p) {
                if (p.CountryId() == val.Id())
                    states.push(p);
            });
        });

        client().Address().State.subscribe(function (val) {
            cities([]);
            $.each(allCities(), function(i, p) {
                if (p.StateId() == val.Id())
                    cities.push(p);
            });
        });

        client().Name.subscribe(function (val) {
            if (val.length >= 3) {
                clientSearchService.clientsSearch({ query: val }, function (result) {
                        $.each(result, function (i, p) {
                            existingClientNames.push(p.Name);
                        });
                });
            }
        });

        var init = function () {
            client().Name("");
            client().Description("");
            client().Website("");
            client().Address().Street1("");
            client().SelectedIndustry("");
            client().SelectedPriority("");
            validationErrors = ko.validation.group(client());
            lookups.init();
            $.when(
                amplify.request('industries-lookup'),
                amplify.request('countries-lookup'),
                amplify.request('states-lookup'),
                amplify.request('cities-lookup'),
                amplify.request('priorities-lookup')
            )
                .then(function (industriesLookup, countriesLookup, statesLookup, citiesLookup, prioritiesLookup) {
                    $.each(industriesLookup[0], function (i, p) {
                        var industry = new industryModel().Id(p.Id).Name(p.Name);
                        industries.push(industry);
                    });
                    $.each(countriesLookup[0], function (i, p) {
                        countries.push(new countryModel().Id(p.Id).Name(p.Name));
                    });
                    $.each(statesLookup[0], function (i, p) {
                        allStates.push(new stateModel()
                            .Id(p.Id)
                            .Name(p.Name)
                            .CountryId(p.CountryId));
                    });
                    $.each(citiesLookup[0], function (i, p) {
                        allCities.push(new cityModel().Id(p.Id).Name(p.Name).StateId(p.StateId));
                    });
                    $.each(prioritiesLookup[0], function (i, p) {
                        priorities.push(p);
                    });
                });
        };

        init();
        return {
            industries: industries,
            countries: countries,
            states: states,
            cities: cities,
            client: client,
            createCommand: createCommand,
            isValid: isValid,
            priorities: priorities,
            existingClientNames: existingClientNames,
            contactsTemplate: contactsTemplate
        };
    });