define('vm.clients.list',
    ['ko', 'dataservice.client'],
    function (ko, clientService) {
        var client = function() {
            var self = this;
            self.Id = ko.observable();
            self.Name = ko.observable();
            self.Industry = ko.observable();
            self.Country = ko.observable();
            self.Contacts = ko.observableArray();
            self.NoOfPositions = ko.observable();
            self.BookedRev = ko.observable();
            self.ProjectedRev = ko.observable();
            self.BookedRevWidth = ko.observable();
            self.ProjectedRevWidth = ko.observable();
            self.Status = ko.observable();
            self.StatusClass = ko.observable();
            self.TechnologyAndCountry = ko.observable();
            self.Priority = ko.observable();
            self.clickCommand = ko.asyncCommand({
                execute: function(complete) {
                    window.location = "/rr/clients/" + Id;
                    complete();
                },
                canexecute: function(isExecuting) {
                    return !isExecuting;
                }
            });
            self.StatusColor = ko.computed(function() {
                return 'yellow';
            });
        };
        
        var
            clients = ko.observableArray(),
            templateName = 'clients.list';

        var init = function() {
            clientService.search(null, {
                success: function (result) {
                    $.each(result, function (i, p) {
                        console.log('result');
                        console.log(p.Name);
                        clients.push(new client()
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
            templateName: templateName
        };
    });