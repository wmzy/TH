$(function() {
    $(".selectize").each(function() {
        var options = $(this).data("options").split(";");
        var optionsArr = [];
        var optgroupsArr = [];
        if (options.length === 2) {
            var groups = options[0].split(",");
            options = options[1].split(",");
            for (var i = groups.length - 1; i >= 0; --i) {
                optgroupsArr.push({ value: groups[i], label: groups[i] });
                var opt = options[i].split(":");
                for (var j = opt.length - 1; j >= 0; --j) {
                    optionsArr.push({ text: opt[j], value: opt[j], optgroup: groups[i] });
                }
            }
        } else {
            var opt = options[0].split(":");
            for (var i = opt.length - 1; i >= 0; --i) {
                optionsArr.push({ text: opt[i], value: opt[i] });
            }
        }
        $(this).selectize({
            create: $(this).data("create"),
            options: optionsArr,
            optgroups: optgroupsArr,
            sortField: "text",
            maxItems: 1
        });
    });
});