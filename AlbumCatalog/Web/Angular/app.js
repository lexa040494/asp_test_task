(function () {
    "use strict";

    angular.module("Web.Services", []);
    angular.module("Web.Controllers", []);
    angular.module("Web.Directives", []);
    angular.module("Web.Externals", ["ui.router", "ngCookies", "ui.bootstrap", "toaster", "ngSanitize", "ngTouch", "ngAnimate", "ui.grid", "ui.grid.selection", 'ui.grid.resizeColumns', 'ui.grid.moveColumns', 'ui.grid.cellNav', 'ui.grid.autoResize', 'ui.grid.pagination', 'ui.grid.grouping', 'ui.grid.edit', 'ui.grid.rowEdit']);


    var app = angular.module("Web", ["Web.Services", "Web.Directives", "Web.Externals", "Web.Controllers"]);

    app.run(["$rootScope", "$location", "$http", "$state", "$cookies", "toaster", "loadingService", "$window",
        function ($rootScope, $location, $http, $state, $cookies, toaster, loadingService, $window) {
            $rootScope.loadingShow = function () {
                $rootScope.loadingIsShow = loadingService.show(); // loading
            };

            $rootScope.loadingHide = function () {
                $rootScope.loadingIsShow = loadingService.hide();
            };

            $rootScope.toaster = function (type, message, timeout, clickHandler) {
                toaster.pop(type, null, message, timeout, null, clickHandler);
            };

            Array.prototype.find = function (predicate) {
                if (this == null) {
                    throw new TypeError('Array.prototype.findIndex called on null or undefined');
                }
                if (typeof predicate !== 'function') {
                    throw new TypeError('predicate must be a function');
                }
                var list = Object(this);
                var length = list.length >>> 0;
                var thisArg = arguments[1];
                var value;

                for (var i = 0; i < length; i++) {
                    value = list[i];
                    if (predicate.call(thisArg, value, i, list)) {
                        return value;
                    }
                }
                return null;
            };
            Array.prototype.findIndex = function (predicate) {
                if (this == null) {
                    throw new TypeError('Array.prototype.findIndex called on null or undefined');
                }
                if (typeof predicate !== 'function') {
                    throw new TypeError('predicate must be a function');
                }
                var list = Object(this);
                var length = list.length >>> 0;
                var thisArg = arguments[1];
                var value;

                for (var i = 0; i < length; i++) {
                    value = list[i];
                    if (predicate.call(thisArg, value, i, list)) {
                        return i;
                    }
                }
                return -1;
            };

            $location.path('/album');
        }
    ]);

})();