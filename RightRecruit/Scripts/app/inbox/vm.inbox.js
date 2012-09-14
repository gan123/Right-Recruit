define('vm.inbox',
    ['ko', 'jquery'],
    function (ko, $) {
        var open = ko.observable('Open (10)'),
            inprogress = ko.observable(),
            onhold = ko.observable(),
            closed = ko.observable(),
            cancelled = ko.observable(),
            filterToggleCommand = ko.asyncCommand({
                execute: function (complete) {
                    $("#filterPanel").slideToggle();
                    complete();
                },
                canexecute : function (isExecuting) {
                    return !isExecuting;
                }
            }),
            updatesToggleCommand = ko.asyncCommand({
                execute: function (complete) {
                    $("#updatesPanel").slideToggle();
                    complete();
                },
                canexecute: function (isExecuting) {
                    return !isExecuting;
                }
            });

        return {
            open: open,
            inprogress: inprogress,
            onhold: onhold,
            closed: closed,
            cancelled: cancelled,
            filterToggleCommand: filterToggleCommand,
            updatesToggleCommand: updatesToggleCommand
        };
    });