define('model.clientSummary',
    ['ko'],
    function(ko) {
        var ClientSummary = function () {
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
                execute: function (complete) {
                    window.location = "/rr/clients/" + Id;
                    complete();
                },
                canexecute: function (isExecuting) {
                    return !isExecuting;
                }
            });
            self.StatusColor = ko.computed(function () {
                return 'yellow';
            });
        };

        return ClientSummary;
    });