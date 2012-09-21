define('model.state',
    ['ko'],
    function (ko) {
        var State = function () {
            var self = this;
            self.Id = ko.observable();
            self.Name = ko.observable();
            self.CountryId = ko.observable();
        };

        return State;
    });