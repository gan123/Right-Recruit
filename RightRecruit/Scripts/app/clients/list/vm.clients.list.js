define('vm.clients.list',
    ['ko', 'dataservice.client', 'model.clientSummary', 'dataservice.lookups', 'model.industry'],
    function (ko, clientService, clientSummary, lookups, industry) {
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

        var init = function() {
            clientService.search(null, {
                success: function (result) {
                    total(result.Total);
                    showing(result.Showing);
                    $.each(result.Clients, function (i, p) {
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
                }
            });

            lookups.priorities(null, {
                success: function (result) {
                    $.each(result, function (i, p) {
                        priorities.push(p);
                    });
                }
            });
            
            lookups.industries(null, {
                success: function (result) {
                    $.each(result, function (i, p) {
                        industries.push(new industry().Id(p.Id).Name(p.Name));
                    });
                }
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