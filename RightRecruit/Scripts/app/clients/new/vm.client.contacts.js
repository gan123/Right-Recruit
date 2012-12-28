define('vm.client.contacts',
    ['jquery', 'ko', 'model.contact'],
    function($, ko, contactModel) {
        var contactName = ko.observable(),
            contactTitle = ko.observable(),
            contactPhone = ko.observable(),
            contactEmail = ko.observable(),
            contacts = ko.observableArray([]),
            addContactCommand = ko.asyncCommand({
                execute: function(complete) {
                    var newContact = new contactModel()
                        .Name(ContactName)
                        .Phone(new phoneModel().Landline(ContactPhone))
                        .Email(ContactEmail)
                        .Title(ContactTitle);
                    Contacts.push(newContact);
                    complete();
                    console.log(Contacts().length);
                },
                canexecute: function(isExecuting) {
                    return !isExecuting;
                }
            }),
            removeContactCommand = ko.asyncCommand({
                execute: function(complete) {
                    Contacts.remove(this);
                    complete();
                },
                canexecute: function(isExecuting) {
                    return true;
                }
            }),
            isValid = ko.computed(function() {
                return contacts().length > 0;
            }),
            templateName = 'client.create.contacts';

        return {
            contactName: contactName,
            contactTitle: contactTitle,
            contactPhone: contactPhone,
            contactEmail: contactEmail,
            contacts: contacts,
            addContactCommand: addContactCommand,
            removeContactCommand: removeContactCommand,
            isValid: isValid,
            templateName: templateName
        };
    });