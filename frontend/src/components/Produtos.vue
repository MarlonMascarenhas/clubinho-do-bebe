<template>
  <v-container>
      <h1>Produtos</h1>
  </v-container>
</template>

<script>
const axios = require('axios');

export default {
	name: 'Produtos',
	data: () => ({
		info: null
	}),
	mounted () {
		axios
			.get('https://localhost:44330/api/Produto')
			.then(response => (this.info = response))
	}
}
</script>
