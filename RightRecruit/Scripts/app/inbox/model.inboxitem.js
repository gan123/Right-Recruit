define('model.inboxitem',
    ['ko'],
    function (ko) {
        var Item = function() {
            var self = this;
            self.Id;
            self.Name;
        };

        return Item;
    });