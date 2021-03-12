import { dataGovService } from '../_services'

const state = {
    all: {}
}

const actions = {
    getCarparkAvailability({ commit }) {
        commit('getCarparkAvailabilityRequest');

        dataGovService.getCarparkAvailability()
            .then(
                items => commit('getCarparkAvailabilitySuccess', items),
                error => commit('getCarparkAvailabilityFailure', error)
            )
    }
};

const mutations = {
    getCarparkAvailabilityRequest(state) {
        state.all = { loading: true };
    },
    getCarparkAvailabilitySuccess(state, items) {
        state.all = { items: items.data };
    },
    getCarparkAvailabilityFailure(state, error) {
        state.all = { error };
    }
};

export const dataGov = {
    namespaced: true,
    state,
    actions,
    mutations
};
