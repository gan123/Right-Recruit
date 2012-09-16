define('vm.client.quicksearch',
    ['jquery', 'ko', 'dataservice.search'],
    function ($, ko, searchService) {
        var
            selectedClient = ko.observable(),
            search = function(request, response) {
                searchService.clientsSearch({ query: request.term }, function (data) {
                    response($.map(data, function (item) {
                        return {
                            HighlightedName: highlight(item.Name, request.term),
                            Id: item.Id,
                            Name: item.Name,
                            Industry: item.Industry,
                            Country: item.Country
                        };
                    }));
                });
            },
            template = function (ul, item) {
                return $("<li></li>")
                    .data("item.autocomplete", item)
                    .append("<a style='width:250px;'><span>" + item.HighlightedName + "</span><br /><span class='mildText small'>" + item.Industry + "</span><span class='mildText small floatRight'>" + item.Country + "</a>")
                    .appendTo(ul);
            },
            displayName = ko.computed(function () {
                var name = selectedClient() == undefined ? null : selectedClient().Name;
                console.log(name);
                return name;
            }),
            select = function (event, ui) {
                console.log('selected');
                selectedClient(ui.item);
            };
        
        function highlight(s, t) {
            var matcher = new RegExp("(" + $.ui.autocomplete.escapeRegex(t) + ")", "ig");
            return s.replace(matcher, "<span style='color:#0094cd;'>$1</span>");
        }
        
        return {
            search: search,
            select: select,
            displayName: displayName,
            selectedClient: selectedClient,
            template: template
        };
    });