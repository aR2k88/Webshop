import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        themes: {
            light: {
                primary: '#917255',
                secondary: '#F0EFED',
                background: '#F0EFED'
            }
        }
    }
});
