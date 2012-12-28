define('vm.client.quicksearch',
    ['jquery', 'ko', 'dataservice.search', 'amplify'],
    function ($, ko, searchService, amplify) {
        var
            selectedClientId = ko.observable(),
            selectedClientName = ko.observable(""),
            search = function (request, response) {
                amplify.request('client-quicksearch', { query: request.term })
                    .done(function(data, status) {
                        $(".search").removeAttr('disabled');
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
            select = function (event, ui) {
                selectedClientId(ui.item.Id);
                selectedClientName(ui.item.Name);
                return (false);
            };

        searchService.init();
        function highlight(s, t) {
            var matcher = new RegExp("(" + $.ui.autocomplete.escapeRegex(t) + ")", "ig");
            return s.replace(matcher, "<span style='color:#0094cd;'>$1</span>");
        }
        
        return {
            search: search,
            select: select,
            selectedClientId: selectedClientId,
            selectedClientName: selectedClientName,
            template: template
        };
    });