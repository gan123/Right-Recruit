define('model.client',
    ['ko', 'model.industry', 'model.address', 'model.phone', 'model.contact'],
    function (ko, industryModel, addressModel, phoneModel, contactModel) {
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
            self.ContactName = ko.observable();
            self.ContactTitle = ko.observable();
            self.ContactPhone = ko.observable();
            self.ContactEmail = ko.observable();
            self.Contacts = ko.observableArray();
            self.AddContactCommand = ko.asyncCommand({
                execute: function (complete) {
                    var newContact = new contactModel()
                        .Name(self.ContactName)
                        .Phone(new phoneModel().Landline(self.ContactPhone))
                        .Email(self.ContactEmail)
                        .Title(self.ContactTitle);
                    self.Contacts.push(newContact);
                    complete();
                    console.log(self.Contacts().length);
                },
                canexecute: function(isExecuting) {
                    return !isExecuting;
                }
            });
            self.RemoveContactCommand = ko.asyncCommand({
                execute: function (complete) {
                    self.Contacts.remove(this);
                    complete();
                },
                canexecute: function(isExecuting) {
                    return true;
                }
            });
        };

        return Client;
    });