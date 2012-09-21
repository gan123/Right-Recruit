$(function () {
    requirejs(['vm.clients.create', 'binder'], load);

    function load() {
        require(['vm.clients.create', 'binder'], function (vm, b) {
            console.log('in');
            b.bind(vm, "#clients-create");
        });
    }
})