import { userService } from '../_services';

const state = {
    all: {}
};

const actions = {
    getProfile({ commit }) {
        commit('getProfileRequest');

        userService.getProfile()
            .then(
                profile => commit('getProfileSuccess', profile),
                error => commit('getProfileFailure', error)
            )
    }
};

const mutations = {
    getProfileRequest(state) {
        state.all = { loading: true };
    },
    getProfileSuccess(state, profile) {
        state.all = { profile: profile.data };
    },
    getProfileFailure(state, error) {
        state.all = { error };
    }
};

export const users = {
    namespaced: true,
    state,
    actions,
    mutations
};
