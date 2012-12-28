define('vm.client.address',
    ['jquery', 'ko', 'amplify', 'model.address', 'dataservice.lookups', 'model.country', 'model.state', 'model.city'],
    function($, ko, amplify, addressModel, lookupsService, countryModel, stateModel, cityModel) {
        var address = ko.observable(new addressModel()),
            countries = ko.observableArray(),
            allStates = ko.observableArray(),
            states = ko.observableArray([]),
            allCities = ko.observableArray(),
            cities = ko.observableArray([]),
            validationErrors = ko.validation.group(address()),
            init = function () {
                lookupsService.init();
                $.when(
                    amplify.request('countries-lookup'),
                    amplify.request('states-lookup'),
                    amplify.request('cities-lookup')
                )
                    .then(function(countriesLookup, statesLookup, citiesLookup) {
                        $.each(countriesLookup[0], function(i, p) {
                            countries.push(new countryModel().Id(p.Id).Name(p.Name));
                        });
                        $.each(statesLookup[0], function(i, p) {
                            allStates.push(new stateModel()
                                .Id(p.Id)
                                .Name(p.Name)
                                .CountryId(p.CountryId));
                        });
                        
                        $.each(citiesLookup[0], function(i, p) {
                            allCities.push(new cityModel().Id(p.Id).Name(p.Name).StateId(p.StateId));
                        });
                        
                        address().Country.subscribe(function (val) {
                            if (val != undefined) {
                                states([]);
                                $.each(allStates(), function (i, p) {
                                    if (p.CountryId() == val.Id())
                                        states.push(p);
                                });
                            }
                        });

                        address().State.subscribe(function (val) {
                            if (val != undefined) {
                                cities([]);
                                $.each(allCities(), function(i, p) {
                                    if (p.StateId() == val.Id())
                                        cities.push(p);
                                });
                            }
                        });
                    });
            },
            templateName = 'client.create.address',
            isValid = ko.computed(function () {
                return validationErrors().length === 0;
            });

        return {
            address: address,
            init: init,
            countries: countries,
            states: states,
            cities: cities,
            templateName: templateName,
            isValid: isValid
        };
    });