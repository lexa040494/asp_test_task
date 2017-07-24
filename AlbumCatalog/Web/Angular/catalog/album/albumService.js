(function () {
    "use strict";

    function albumService($cookies, $http, $rootScope, $q) {
        var service = {};

        service.GetAllAlbums = function () {
            var deferred = $q.defer();

            $http.get('api/album')
           .then(function (response) {
               deferred.resolve(response.data);
           }).catch(function onError(response) {
               deferred.reject(response.data);
           });

            return deferred.promise;

        };

        return service;
    };

    angular
        .module("Web.Services")
        .service("albumService", ["$cookies", "$http", "$rootScope", "$q", albumService]);
})();
