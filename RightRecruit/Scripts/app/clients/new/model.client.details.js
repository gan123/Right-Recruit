define('model.client.details',
    ['ko', 'model.phone'],
    function (ko, phoneModel) {
        var Details = function () {
            var self = this;
            var phone = new phoneModel();
            self.Name = ko.observable().extend({ required: true, message: 'Please provide a name' });
            self.AlternativeNames = ko.observable();
            self.Description = ko.observable().extend({ required: true });
            self.Website = ko.observable().extend({ required: true });
            self.SelectedIndustry = ko.observable().extend({ required: true });
            self.Phone = ko.observable(phone).extend({ required: true });
            self.SelectedPriority = ko.observable().extend({ required: true });
            self.PhoneValidationErrors = ko.validation.group(phone);
        };

        return Details;
    });