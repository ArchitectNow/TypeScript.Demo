interface ICurrentUser {
    userId: string;
}

((): void => {
    'use strict';

    var currentUser: ICurrentUser = {
        userId: ''
    };

    angular
        .module('app')
        .value('currentUser', currentUser);
})();