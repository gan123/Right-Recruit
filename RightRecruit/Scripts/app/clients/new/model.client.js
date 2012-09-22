define('model.client',
    ['ko', 'model.industry', 'model.address'],
    function (ko, industryModel, addressModel) {
        var Client = function() {
            var self = this;
            var address = new addressModel();
            self.Name = ko.observable().extend({ required: true });
            self.Description = ko.observable().extend({ required: true });
            self.Website = ko.observable().extend({ required: true });
            self.SelectedIndustry = ko.observable().extend({ required: true });
            self.Address = ko.observable(address).extend({ required: true });
            self.SelectedPriority = ko.observable().extend({required: true});
            self.ValidationErrors = ko.validation.group(address);
        };

        return Client;
    });