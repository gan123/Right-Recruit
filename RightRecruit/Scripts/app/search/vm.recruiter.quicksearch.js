define('vm.recruiter.quicksearch',
    ['jquery', 'ko', 'dataservice.search'],
    function ($, ko, searchService) {
        var
            selectedRecruiter = ko.observable(),
            search = function (request, response) {
                searchService.recruitersSearch({ query: request.term }, function (data) {
                    response($.map(data, function (item) {
                        return {
                            HighlightedName: highlight(item.Name, request.term),
                            Id: item.Id,
                            Name: item.Name,
                            Role: item.Role
                        };
                    }));
                });
            },
            template = function (ul, item) {
                return $("<li></li>")
                    .data("item.autocomplete", item)
                    .append("<a style='width:250px;'><span>" + item.HighlightedName + "</span><br /><span class='mildText small'>" + item.Role + "</span></a>")
                    .appendTo(ul);
            },
            displayName = ko.computed(function () {
                var name = selectedRecruiter() == undefined ? null : selectedRecruiter().Name;
                console.log(name);
                return name;
            }),
            select = function (event, ui) {
                selectedRecruiter(ui.item);
            };

        function highlight(s, t) {
            var matcher = new RegExp("(" + $.ui.autocomplete.escapeRegex(t) + ")", "ig");
            return s.replace(matcher, "<span style='color:#0094cd;'>$1</span>");
        }

        return {
            search: search,
            select: select,
            displayName: displayName,
            selectedRecruiter: selectedRecruiter,
            template: template
        };
    });