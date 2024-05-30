const baseUrl = 'https://localhost:44306/api/WoodPellets'; // Opdater URL-adressen

Vue.createApp({
    data() {
        return {
            woodPellets: [],
            selectedWoodPellet: null,
            errorMessage: ''
        };
    },
    created() {
        this.getWoodPellets();
    },
    methods: {
        async getWoodPellets() {
            const response = await axios.get(baseUrl);
            this.woodPellets = await response.data;
        },
        async getWoodPelletById(id) {
            axios.get(`${baseUrl}/${id}`)
                .then(response => {
                    this.selectedWoodPellet = response.data;
                })
                .catch(error => {
                    console.error(error);
                    this.errorMessage = 'Failed to retrieve Wood Pellet by Id';
                });
        },
        addWoodPellet(woodPellet) {
            axios.post(baseUrl, woodPellet)
                .then(response => {
                    this.getWoodPellets();
                })
                .catch(error => {
                    console.error(error);
                    this.errorMessage = 'Failed to add Wood Pellet';
                });
        }
    }
}).mount('#app');
