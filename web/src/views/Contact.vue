<template>
  <v-container style="max-width:500px">
    <v-layout row wrap>
      <v-flex xs12>
        <span class="mainFont">Kontakt oss</span>
      </v-flex>
      <v-flex xs12 class="mt-5 mb-5">
        <v-divider color="black"></v-divider>
      </v-flex>
      <v-flex xs12 class="mb-5">
        <span>Kanskje en forklarende tekst her</span>
      </v-flex>
      <v-flex xs12 sm6>
        <v-text-field label="Ditt navn" class="mr-5" outlined></v-text-field>
      </v-flex>
      <v-flex> 
        <v-text-field label="Telefonnummer" class="mr-5" outlined></v-text-field>
      </v-flex>
      <v-flex xs12>
        <v-text-field label="Din e-post" class="mr-5" outlined></v-text-field>
      </v-flex>
      <v-flex xs12>
        <v-textarea label="Din beskjed" class="mr-5" outlined></v-textarea>
      </v-flex>
      <v-flex xs12>
        <v-btn color="primary" class="text-none">Send inn</v-btn>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  name: "Contact"
}
</script>

<style scoped>
.mainFont {
  font-size:1.3rem;
  font-weight: bold;
}
</style>