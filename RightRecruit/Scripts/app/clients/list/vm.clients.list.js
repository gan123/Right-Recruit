define('vm.clients.list',
    ['ko', 'dataservice.client', 'model.clientSummary'],
    function (ko, clientService, clientSummary) {
        var
            clients = ko.observableArray(),
            total = ko.observable(),
            showing = ko.observable(),
            filterToggleCommand = ko.asyncCommand({
                execute: function (complete) {
                    $("#filterPanel").slideToggle();
                    complete();
                },
                canexecute: function (isExecuting) {
                    return !isExecuting;
                }
            }),
            addNewClientCommand = ko.asyncCommand({
                execute: function (complete) {
                    window.location = '/rr/clients/create';
                    complete();
                },
                canexecute: function (isExecuting) {
                    return !isExecuting;
                }
            }),
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
        };

        init();

        return {
            clients: clients,
            total: total,
            showing: showing,
            templateName: templateName,
            filterToggleCommand: filterToggleCommand,
            addNewClientCommand: addNewClientCommand
        };
    });