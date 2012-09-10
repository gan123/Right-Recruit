define('binder',
    ['jquery', 'ko'], function ($, ko) {
        var bind = function(vm, viewName) {
            ko.applyBindings(vm, getView(viewName));
        },
            getView = function(viewName) {
                return $(viewName).get(0);
            };

        return {
            bind: bind
        };
    });