define('model.client',
    ['ko', 'model.industry', 'model.address', 'model.phone'],
    function (ko, industryModel, addressModel, phoneModel) {
        var Client = function() {
            var self = this;
            var address = new addressModel();
            var phone = new phoneModel();
            self.Name = ko.observable().extend({ required: true });
            self.AlternativeNames = ko.observable();
            self.Description = ko.observable().extend({ required: true });
            self.Website = ko.observable().extend({ required: true });
            self.SelectedIndustry = ko.observable().extend({ required: true });
            self.Address = ko.observable(address).extend({ required: true });
            self.Phone = ko.observable(phone).extend({ required: true });
            self.SelectedPriority = ko.observable().extend({required: true});
            self.AddressValidationErrors = ko.validation.group(address);
            self.PhoneValidationErrors = ko.validation.group(phone);
        };

        return Client;
    });