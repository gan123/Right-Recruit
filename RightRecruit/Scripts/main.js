(function () {
    var root = this;
    
    define3rdPartyModules();
    loadPluginsAndBoot();

    configureExternalTemplates = function() {
        infuser.defaults.templatePrefix = "_";
        infuser.defaults.templateSuffix = ".tmpl.html";
        infuser.defaults.templateUrl = "/Tmpl";
    };

    function define3rdPartyModules() {
        // These are already loaded via bundles. 
        // We define them and put them in the root object.
        define('jquery', [], function () { return root.jQuery; });
        define('ko', [], function () { return root.ko; });
        define('amplify', [], function () { return root.amplify; });
        define('infuser', [], function () { return root.infuser; });
        define('moment', [], function () { return root.moment; });
        define('sammy', [], function () { return root.Sammy; });
        define('toastr', [], function () { return root.toastr; });
        define('underscore', [], function () { return root._; });
        define('qtip', [], function () { return root.qtip; });
    }

    function loadPluginsAndBoot() {
        // Plugins must be loaded after jQuery and Knockout, 
        // since they depend on them.
        requirejs([
            'ko.bindingHandlers',
            'ko.debug.helpers',
            'config',
            'signin',
            'signout'
        ], boot);
    }

    function boot() {
        require(['signin', 'signout', 'infuser'], function(si, so, infuser) {
            si.init();
            so.init();
            
            infuser.defaults.templatePrefix = "_";
            infuser.defaults.templateSuffix = ".tmpl.html";
            infuser.defaults.templateUrl = "Tmpl";
        });
    }
})();