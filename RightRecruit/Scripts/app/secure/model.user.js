define('model.user',
    ['ko'],
    function(ko) {
        var User = function() {
            var self = this;
            self.UserName = ko.observable().extend({required: true});
            self.Password = ko.observable().extend({ required: true });
            self.RememberMe = ko.observable('false');
        };

        return User;
    });