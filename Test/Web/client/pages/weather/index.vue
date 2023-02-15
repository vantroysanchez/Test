<template>
  <div>
    <b-card title="WeatherForecast" sub-title="Prueba de consumo de api">
      <b-table v-if="items" striped hover :items="items" :fields="fields">
      </b-table>
    </b-card>
  </div>
</template>

<script>
import axios from "axios";

export default {
  layout: "default",
  data() {
    return {
      Id: 1,
      fields: [
        {
          key: "$id",
          label: "Id",
        },
        {
          key: "date",
        },
        {
          key: "temperatureC",
        },
        {
          key: "temperatureF",
        },
        {
          key: "summary",
        },
      ],
      items: [{}],
    };
  },
  methods: {
    getAll() {
      axios
        .get("https://localhost:44377/WeatherForecast")
        .then((result) => {
          this.items = result.data;
        });
    },
  },
  created() {
    this.getAll();
  },
};
</script>

<style scoped></style>
