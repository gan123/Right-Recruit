define('model.city',
    ['ko'],
    function (ko) {
        var City = function () {
            var self = this;
            self.Id = ko.observable();
            self.Name = ko.observable();
            self.StateId = ko.observable();
        };

        return City;
    });