define('vm.client.details',
    ['jquery', 'ko', 'model.client.details', 'dataservice.search', 'amplify', 'model.industry', 'dataservice.lookups'],
    function($, ko, clientDetailsModel, searchService, amplify, industryModel, lookupsService) {
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
            init = function () {
                lookupsService.init();
                searchService.init();

                $.when(
                    amplify.request('industries-lookup'),
                    amplify.request('priorities-lookup')
                )
                    .then(function(industriesLookup, prioritiesLookup) {
                        $.each(industriesLookup[0], function(i, p) {
                            industries.push(new industryModel().Id(p.Id).Name(p.Name));
                        });
                        $.each(prioritiesLookup[0], function(i, p) {
                            priorities.push(p);
                        });
                    });
            },
            templateName = 'client.create.details',
            showRelatedClients = ko.observable(false),
            isNotDuplicateClient = ko.observable(false),
            isValid = ko.computed(function () {
                return validationErrors().length === 0 && isNotDuplicateClient();
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
            isValid: isValid,
            templateName: templateName,
            isNotDuplicateClient: isNotDuplicateClient
        };
    });