define('vm.clients.list',
    ['jquery', 'amplify', 'ko', 'dataservice.client', 'model.clientSummary', 'dataservice.lookups', 'model.industry'],
    function ($, amplify, ko, clientService, clientSummary, lookups, industry) {
        var
            clients = ko.observableArray(),
            total = ko.observable(),
            showing = ko.observable(),
            priorities = ko.observableArray(),
            selectedPriority = ko.observable(),
            addNewClientCommand = ko.asyncCommand({
                execute: function (complete) {
                    window.location = '/rr/clients/create';
                    complete();
                },
                canexecute: function (isExecuting) {
                    return !isExecuting;
                }
            }),
            industries = ko.observableArray(),
            selectedIndustry = ko.observable(),
            templateName = 'clients.list';

        var init = function () {
            lookups.init();
            clientService.init();
            amplify.request('clients-list')
                .done(function(data, status) {
                    total(data.Total);
                    showing(data.Showing);
                    $.each(data.Clients, function (i, p) {
                        clients.push(new clientSummary()
                            .Id(p.Id)
                            .Name(p.Name)
                            .Industry(p.Industry)
                            .Country(p.Country)
                            .NoOfPositions(p.NoOfPositions)
                            .Contacts(p.Contacts)
                            .BookedRev(p.BookedRev)
                            .ProjectedRev(p.ProjectedRev)
                            .BookedRevWidth(p.BookedRevWidth)
                            .ProjectedRevWidth(p.ProjectedRevWidth)
                            .Status(p.Status)
                            .StatusClass(p.StatusClass)
                            .TechnologyAndCountry(p.TechnologyAndCountry)
                            .Priority(p.Priority)
                        );
                    });
                });

            $.when(
                amplify.request('industries-lookup'),
                amplify.request('priorities-lookup')
            )
                .then(function (industriesLookup, prioritiesLookup) {
                    $.each(industriesLookup[0], function (i, p) {
                        industries.push(new industry().Id(p.Id).Name(p.Name));
                    });
                    $.each(prioritiesLookup[0], function (i, p) {
                        priorities.push(p);
                    });
                });
        };

        init();

        return {
            clients: clients,
            total: total,
            showing: showing,
            templateName: templateName,
            addNewClientCommand: addNewClientCommand,
            priorities: priorities,
            selectedPriority: selectedPriority,
            industries: industries,
            selectedIndustry: selectedIndustry
        };
    });