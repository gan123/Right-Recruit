define('model.contact',
    ['ko', 'model.phone'],
    function (ko, phone) {
        var Contact = function() {
            var self = this;
            self.Id = ko.observable();
            self.Name = ko.observable();
            self.Phone = ko.observable(new phone());
            self.Email = ko.observable();
            self.Title = ko.observable();
        };

        return Contact;
    });