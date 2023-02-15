<template>
  <div>
    <b-button
      @click="showModalCreate = true"
      v-b-modal.modal-create
      variant="outline-dark"
      class="float-right mb-3"
      >[+] Agregar libro</b-button
    >
    <b-modal v-model="showModalCreate" id="modal-create" size="lg">
      <template #modal-title> Crear libro </template>
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
                v-model="book.description"
              ></b-form-input>
            </b-col>
            <b-col>
              <label class="mr-sm-2">Editorial</label>
              <b-form-select v-model="book.editorialId">
                <b-form-select-option
                  :key="index"
                  v-for="(item, index) in editorial"
                  :value="item.id"
                  >{{ item.description }}</b-form-select-option
                >
              </b-form-select>
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
      book: {
        description: "",
        status: true,
        editorialId: 1,
        editorial: null,
      },
      editorial: [{}],
    };
  },
  methods: {
    getEditorial() {
      axios
        .get("https://localhost:44377/api/Editorial")
        .then((result) => {
          this.editorial = result.data.$values;
        });
    },

    Save() {
      axios
        .post("https://localhost:44377/api/Book", this.book)
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
  created() {
    this.getEditorial();
  },
};
</script>

<style></style>
