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

        return {
            init: init
        };
    });