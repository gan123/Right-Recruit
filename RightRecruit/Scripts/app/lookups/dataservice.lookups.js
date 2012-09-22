define('dataservice.lookups',
    ['amplify'],
    function (amplify) {
        var init = function() {
            amplify.request.define('industries-lookup', 'ajax', {
                url: '/rr/lookup/industries',
                dataType: 'json',
                type: 'GET'
            });
            
            amplify.request.define('countries-lookup', 'ajax', {
                url: '/rr/lookup/countries',
                dataType: 'json',
                type: 'GET'
            });
            
            amplify.request.define('states-lookup', 'ajax', {
                url: '/rr/lookup/states',
                dataType: 'json',
                type: 'GET'
            });
            
            amplify.request.define('cities-lookup', 'ajax', {
                url: '/rr/lookup/cities',
                dataType: 'json',
                type: 'GET'
            });
            
            amplify.request.define('priorities-lookup', 'ajax', {
                url: '/rr/lookup/priorities',
                dataType: 'json',
                type: 'GET'
            });
        };

        var industries = function(data, callbacks) {
            amplify.request({
                resourceId: 'industries-lookup',
                data: data,
                success: callbacks.success
            });
        };
        
        var countries = function (data, callbacks) {
            amplify.request({
                resourceId: 'countries-lookup',
                data: data,
                success: callbacks.success
            });
        };
        
        var states = function (data, callbacks) {
            amplify.request({
                resourceId: 'states-lookup',
                data: data,
                success: callbacks.success
            });
        };
        
        var cities = function (data, callbacks) {
            amplify.request({
                resourceId: 'cities-lookup',
                data: data,
                success: callbacks.success
            });
        };
        
        var priorities = function (data, callbacks) {
            amplify.request({
                resourceId: 'priorities-lookup',
                data: data,
                success: callbacks.success
            });
        };

        init();

        return {
            industries: industries,
            countries: countries,
            states: states,
            cities: cities,
            priorities: priorities
        };
    });