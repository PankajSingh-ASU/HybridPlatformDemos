function __processArg(obj, key) {
    var arg = null;
    if (obj) {
        arg = obj[key] || null;
        delete obj[key];
    }
    return arg;
}

function Controller() {
    function init() {
        $.window.removeEventListener("open", init);
        var diff = Alloy.Globals.layout.list.row.imageHeight - Alloy.Globals.layout.list.row.height;
        tableview_offset_per_px = diff / $.tableview.rect.height;
        tableview_cell_offset = tableview_offset_per_px * Alloy.Globals.layout.list.row.height;
        if ("search" == args.type) {
            Ti.Analytics.featureEvent("view:search_results");
            Ti.Analytics.featureEvent("view:search_results." + args.query);
            search(args.query);
        } else {
            Ti.Analytics.featureEvent("view:" + args.type);
            Ti.Analytics.featureEvent("view:" + args.type + "." + args.id);
            fetchCollection(args.type, args.id);
        }
        $.navbar.background_view.opacity = 0;
    }
    function fetchCollection(type) {
        Data["movies_get_" + type](function(error, e) {
            if (error) Ti.API.error("Error: " + JSON.stringify(JSON.parse(e), null, 4)); else {
                $.navbar.title_label.text = e.title.toUpperCase();
                movies = e.movies;
                populateMovies(movies);
            }
        });
    }
    function search(query) {
        $.navbar.title_label.text = "Results for '" + query + "'";
        Data.movies_search(query, function(error, e) {
            if (error) Ti.API.error(error); else {
                movies = e;
                populateMovies(movies);
            }
        });
    }
    function populateMovies(movies) {
        tableView_data = [];
        var tableView_rows = [];
        for (var i = 0; i < movies.length; i++) {
            var movie = movies[i];
            var cell = Alloy.createController("views/movies_list_cell");
            cell.updateViews({
                "#title_label": {
                    text: movie.title
                },
                "#thumbnail_imageview": {
                    top: cellImageOffset(i),
                    image: theMovieDb.common.getImage({
                        size: Alloy.Globals.backdropImageSize,
                        file: movie.backdrop_path
                    })
                }
            });
            tableView_data.push(cell);
            tableView_rows.push(cell.getView());
        }
        $.tableview.setData(tableView_rows);
        $.activity_indicator.hide();
        var tableview_animation = Ti.UI.createAnimation({
            opacity: 1,
            duration: 500,
            curve: Titanium.UI.ANIMATION_CURVE_EASE_OUT
        });
        $.tableview.animate(tableview_animation);
    }
    function updateTableView(offset) {
        for (var i = 0, num_rows = tableView_data.length; num_rows > i; i++) {
            var row = tableView_data[i];
            row.updateViews({
                "#thumbnail_imageview": {
                    top: cellImageOffset(i, offset)
                }
            });
        }
    }
    function cellImageOffset(idx, scroll_offset) {
        scroll_offset = scroll_offset || 0;
        var offset = (scroll_offset - 64) * tableview_offset_per_px - idx * tableview_cell_offset;
        offset = Math.min(offset, 0);
        offset = Math.max(offset, Alloy.Globals.layout.list.row.height - Alloy.Globals.layout.list.row.imageHeight);
        return offset;
    }
    require("alloy/controllers/BaseController").apply(this, Array.prototype.slice.call(arguments));
    this.__controllerPath = "movies_list";
    this.args = arguments[0] || {};
    if (arguments[0]) {
        {
            __processArg(arguments[0], "__parentSymbol");
        }
        {
            __processArg(arguments[0], "$model");
        }
        {
            __processArg(arguments[0], "__itemTemplate");
        }
    }
    var $ = this;
    var exports = {};
    $.__views.window = Ti.UI.createWindow({
        navBarHidden: true,
        orientationModes: [ Ti.UI.PORTRAIT ],
        backgroundColor: "#000000",
        id: "window"
    });
    $.__views.window && $.addTopLevelView($.__views.window);
    $.__views.tableview_header = Ti.UI.createView({
        backgroundColor: "#b0332a",
        height: 64,
        id: "tableview_header"
    });
    $.__views.pull_view = Ti.UI.createView({
        backgroundColor: "#b0332a",
        id: "pull_view"
    });
    $.__views.tableview = Ti.UI.createTableView({
        top: 0,
        left: 0,
        width: Ti.UI.FILL,
        height: Ti.UI.FILL,
        backgroundColor: "transparent",
        pullBackgroundColor: "#b0332a",
        showVerticalScrollIndicator: false,
        opacity: 0,
        separatorInsets: {
            left: 0,
            right: 0
        },
        separatorStyle: Titanium.UI.iPhone.TableViewSeparatorStyle.NONE,
        headerView: $.__views.tableview_header,
        headerPullView: $.__views.pull_view,
        id: "tableview"
    });
    $.__views.window.add($.__views.tableview);
    $.__views.activity_indicator = Ti.UI.createActivityIndicator({
        style: Ti.UI.iPhone.ActivityIndicatorStyle.BIG,
        height: Ti.UI.SIZE,
        width: Ti.UI.SIZE,
        color: "#ff0000",
        id: "activity_indicator"
    });
    $.__views.window.add($.__views.activity_indicator);
    $.__views.navbar = Alloy.createController("views/navbar", {
        id: "navbar",
        __parentSymbol: $.__views.window
    });
    $.__views.navbar.setParent($.__views.window);
    exports.destroy = function() {};
    _.extend($, $.__views);
    var theMovieDb = require("themoviedb"), Data = require("data");
    var args = arguments[0] || {};
    var movies = [];
    var tableView_data = [];
    var tableview_offset_per_px = 0;
    var tableview_cell_offset = 0;
    $.window.addEventListener("open", init);
    $.tableview.addEventListener("click", function(e) {
        $.tableview.touchEnabled = false;
        tableView_data[e.index].animateClick(function() {
            var movie = movies[e.index];
            Alloy.Globals.Navigator.push("movie", {
                id: movie.id
            });
            setTimeout(function() {
                $.tableview.touchEnabled = true;
            }, 1e3);
        });
    });
    $.tableview.addEventListener("scroll", function(e) {
        var offset = e.contentOffset.y;
        $.navbar.background_view.opacity = Math.min(offset / 44, 1);
        $.navbar.content.opacity = Math.min(1 - offset / 44, 1);
    });
    !function() {
        if (!Ti.App.Properties.getBool(Alloy.Globals.PROPERTY_ENABLE_LIST_ANIMATION)) return;
        $.tableview.addEventListener("postlayout", function tableviewPostLayout(e) {
            var height = e.source.rect.height;
            if (height > 0 && height <= Alloy.Globals.deviceHeight) {
                var diff = Alloy.Globals.layout.list.row.imageHeight - Alloy.Globals.layout.list.row.height;
                tableview_offset_per_px = diff / height;
                tableview_cell_offset = tableview_offset_per_px * Alloy.Globals.layout.list.row.height;
                $.tableview.removeEventListener("postlayout", tableviewPostLayout);
            }
        });
        $.tableview.addEventListener("scroll", function(e) {
            var offset = e.contentOffset.y;
            updateTableView(offset);
        });
    }();
    _.extend($, exports);
}

var Alloy = require("alloy"), Backbone = Alloy.Backbone, _ = Alloy._;

module.exports = Controller;