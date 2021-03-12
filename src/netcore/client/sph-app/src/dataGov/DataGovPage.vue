<template>
    <div>
        <p>
            <router-link to="/">Back to Home</router-link>
        </p>

        <table class="table table-striped">
            <thead>
                <tr>
                    <th scope="col">No.</th>
                    <th scope="col">Total lots</th>
                    <th scope="col">Lot type</th>
                    <th scope="col">Available lot</th>
                    <th scope="col">Last modified time</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in items.items" :key="item.id">
                    <th scope="row">{{item.carpark_number}}</th>
                    <td style="text-align:right;">{{item.carpark_info[0].total_lots}}</td>
                    <td>{{item.carpark_info[0].lot_type}}</td>
                    <td style="text-align:right;">{{item.carpark_info[0].lots_available}}</td>
                    <td>{{item.update_datetime}}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
    computed: {
        ...mapState({
            items: state => state.dataGov.all
        })
    },
    created () {
        this.getCarparkAvailability();
    },
    methods: {
        ...mapActions('dataGov', {
            getCarparkAvailability: 'getCarparkAvailability'
        })
    }
};
</script>