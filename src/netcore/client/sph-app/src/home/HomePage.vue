<template>
    <div>
        <em v-if="users.loading">Loading profile...</em>
        <h1 v-if="users.profile">Hi {{users.profile.firstName}} {{users.profile.lastName}}!</h1>
        <br />
        <hr />
        <p>Choose your action:</p>
        <ul>
            <li><router-link to="/carpark">Carpark Availability</router-link></li>
            <li><router-link to="/login">Logout</router-link></li>
        </ul>
    </div>
</template>

<script>
import { mapState, mapActions } from 'vuex'

export default {
    computed: {
        ...mapState({
            users: state => state.users.all
        })
    },
    created () {
        this.getProfile();
    },
    methods: {
        ...mapActions('users', {
            getProfile: 'getProfile'
        })
    }
};
</script>