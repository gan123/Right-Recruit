define('model.industry',
    ['ko'],
    function(ko) {
        var Industry = function() {
            var self = this;
            self.Id = ko.observable();
            self.Name = ko.observable();
        };

        return Industry;
    });