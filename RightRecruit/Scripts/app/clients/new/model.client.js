define('model.client',
    ['ko', 'model.industry', 'model.address'],
    function (ko, industryModel, addressModel) {
        var Client = function() {
            var self = this;
            self.Name = ko.observable().extend({ required: true, minLength: 3 });
            self.Description = ko.observable().extend({ required: true });
            self.Website = ko.observable().extend({ required: true });
            self.SelectedIndustry = ko.observable().extend({ required: true });
            self.Address = ko.observable(new addressModel());
        };

        return Client;
    });