define('model.country',
    ['ko'],
    function(ko) {
        var Country = function() {
            var self = this;
            self.Id = ko.observable();
            self.Name = ko.observable();
        };

        return Country;
    });