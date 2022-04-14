<template>
  <div>
    <b-button
      @click="showModalCreate = true"
      v-b-modal.modal-create
      variant="outline-dark"
      class="float-right mb-3"
      >[+] Agregar editorial</b-button
    >
    <b-modal v-model="showModalCreate" id="modal-create" size="lg">
      <template #modal-title> Crear Editorial </template>
      <div>
        <b-form>
          <b-row>
            <b-col>
              <label class="mr-sm-2" for="inline-form-input-name"
                >Description</label
              >
              <b-form-input
                id="inline-form-input-name"
                class="mb-2 mr-sm-2 mb-sm-0"
                placeholder="Nombre del libro"
                v-model="editorial.description"
              ></b-form-input>
            </b-col>
          </b-row>
        </b-form>
      </div>
      <template #modal-footer>
        <div class="w-100">
          <b-button
            variant="primary"
            size="sm"
            class="float-right"
            @click="Save()"
          >
            Guardar
          </b-button>
          <b-button
            variant="default"
            size="sm"
            class="float-right"
            @click="showModalCreate = false"
          >
            Cerrar
          </b-button>
        </div>
      </template>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";
import swal from "sweetalert";

export default {
  layout: "default",
  data() {
    return {
      showModalCreate: false,
      editorial: {
        description: "",
        status: true,
      },
    };
  },
  methods: {
    Save() {
      axios
        .post(
          "https://crudlibrary.azurewebsites.net/api/Editorial",
          this.editorial
        )
        .then((result) => {
          swal(
            "Guardado",
            "¡Información guardada satisfactoriamente!",
            "success"
          );
          this.$router.go(0);
        });
    },
  },
};
</script>

<style></style>
