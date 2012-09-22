define('model.address',
    ['ko', 'model.country', 'model.state', 'model.city'],
    function (ko, country, state, city) {
        var Address = function() {
            var self = this;
            self.Street1 = ko.observable().extend({required: true});
            self.Street2 = ko.observable();
            self.Street3 = ko.observable();
            self.Pincode = ko.observable();
            self.Country = ko.observable(new country()).extend({required: true});
            self.State = ko.observable(new state()).extend({ required: true });
            self.City = ko.observable(new city()).extend({ required: true });
        };

        return Address;
    });