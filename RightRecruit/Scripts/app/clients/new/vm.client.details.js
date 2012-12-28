define('vm.client.details',
    ['jquery', 'ko', 'model.client.details', 'dataservice.search', 'amplify', 'model.industry', 'dataservice.lookups', 'model.country', 'model.state', 'model.city'],
    function ($, ko, clientDetailsModel, searchService, amplify, industryModel, lookupsService, countryModel, stateModel, cityModel) {
        var details = ko.observable(
            new clientDetailsModel()
            .Name("")
            .AlternativeNames("")
            .Description("")
            .Website("")
            .SelectedIndustry("")
            .SelectedPriority("")),
            relatedClients = ko.observableArray(),
            validationErrors = ko.validation.group(details()),
            industries = ko.observableArray(),
            priorities = ko.observableArray(),
            countries = ko.observableArray([]),
            allStates = ko.observableArray(),
            states = ko.observableArray([]),
            allCities = ko.observableArray(),
            cities = ko.observableArray([]),
            init = function () {
                lookupsService.init();
                searchService.init();

                $.when(
                    amplify.request('industries-lookup'),
                    amplify.request('priorities-lookup'),
                    amplify.request('countries-lookup'),
                    amplify.request('states-lookup'),
                    amplify.request('cities-lookup')
                )
                    .then(function (industriesLookup, prioritiesLookup, countriesLookup, statesLookup, citiesLookup) {
                        $.each(industriesLookup[0], function(i, p) {
                            industries.push(new industryModel().Id(p.Id).Name(p.Name));
                        });
                        $.each(prioritiesLookup[0], function(i, p) {
                            priorities.push(p);
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
                        
                        details().Address().Country.subscribe(function (val) {
                            if (val != undefined) {
                                states([]);
                                $.each(allStates(), function (i, p) {
                                    if (p.CountryId() == val.Id())
                                        states.push(p);
                                });
                            }
                        });

                        details().Address().State.subscribe(function (val) {
                            if (val != undefined) {
                                cities([]);
                                $.each(allCities(), function (i, p) {
                                    if (p.StateId() == val.Id())
                                        cities.push(p);
                                });
                            }
                        });
                    });
            },
            templateName = 'client.create.details',
            showRelatedClients = ko.observable(false),
            isNotDuplicateClient = ko.observable(false),
            isValid = ko.computed(function () {
                return validationErrors().length === 0 && isNotDuplicateClient() && details().PhoneValidationErrors().length === 0
                    && details().AddressValidationErrors().length === 0;
            });
        
        details().Name.subscribe(function (val) {
            if (val.length >= 3) {
                relatedClients([]);
                amplify.request('client-quicksearch', { query: val })
                    .done(function (data, status) {
                        showRelatedClients(data.length > 0);
                        $.each(data, function (i, p) {
                            relatedClients.push(new clientDetailsModel()
                                .Name(p.Name)
                                .SelectedIndustry(new industryModel().Name(p.Industry)));
                        });
                    });
            } else {
                showRelatedClients(false);
            }
        });

        return {
            details: details,
            relatedClients: relatedClients,
            showRelatedClients: showRelatedClients,
            init: init,
            industries: industries,
            priorities: priorities,
            countries: countries,
            states: states,
            cities: cities,
            isValid: isValid,
            templateName: templateName,
            isNotDuplicateClient: isNotDuplicateClient
        };
    });