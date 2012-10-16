$(function() {
    requirejs(['vm.personalize', 'binder'], function(vm, binder) {
        binder.bind(vm, "#personalize-view");
    });
});