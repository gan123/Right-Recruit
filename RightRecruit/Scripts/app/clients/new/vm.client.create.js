define('vm.clients.create',
    ['jquery', 'amplify', 'ko', 'binder', 'config', 'dataservice.lookups', 'dataservice.client', 'dataservice.search', 'model.industry', 'vm.client.details', 'vm.client.address', 'vm.client.contacts'],
    function ($, amplify, ko, binder, config, lookups, clientService, clientSearchService, industryModel, detailsViewModel, addressViewModel, contactsViewModel) {
        var
            logger = config.logger,
            details = detailsViewModel,
            address = addressViewModel,
            contacts = contactsViewModel,
            createCommand = ko.asyncCommand({
                execute: function (complete) {
                    amplify.request('client-create', ko.toJSON({ client: "" }))
                        .done(function (data, status) {
                            logger.success(config.toasts.savedData);
                            complete();
                        })
                        .fail(function (data, status) {
                            
                        });
                },
                canexecute: function(isExecuting) {
                    console.log(isValid);
                    return !isExecuting && isValid;
                }
            }),
            isNextEnabled = ko.observable(false),
            isSubmitEnabled = ko.observable(false),
            disableNextAndSubmit = function () {
                isNextEnabled(false);
                isSubmitEnabled(false);
            };

        details.isValid.subscribe(function(val) {
            isNextEnabled(val);
        });
        
        address.isValid.subscribe(function (val) {
            isNextEnabled(val);
        });

        var init = function () {
            clientService.init();
            clientSearchService.init();
            details.init();
            address.init();

            binder.bind(details, "#view1");
            binder.bind(address, "#view2");
        };

        init();
        return {
            details: details,
            address: address,
            contacts: contacts,
            createCommand: createCommand,
            isNextEnabled: isNextEnabled,
            isSubmitEnabled: isSubmitEnabled,
            disableNextAndSubmit: disableNextAndSubmit
        };
    });