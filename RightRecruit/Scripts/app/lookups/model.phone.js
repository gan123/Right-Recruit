﻿define('model.phone',
    ['ko'],
    function(ko) {
        var Phone = function() {
            var self = this;
            self.Landline = ko.observable().extend({ required: true });
            self.Fax = ko.observable();
            self.Mobile = ko.observable();
        };

        return Phone;
    });