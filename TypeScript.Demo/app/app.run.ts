interface IAppCookies {
    userId: string;
}

((): void => {
    'use strict';

    angular
        .module('app')
        .run(run);

    run.$inject = [
        '$rootScope'
    ];
    function run(
        $rootScope: ng.IRootScopeService

        ): void {

        $rootScope.$on('$routeChangeError', (): void => {
        });
    }
})();