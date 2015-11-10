((): void => {
    'use strict';

    angular
        .module('app', [
            'app.core',
        /*
         * Features areas
         */
            'app.services',
            'app.features'
        ]);
})();