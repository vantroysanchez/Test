<template>
  <div>
    <b-modal v-model="showModalEdit" id="modal-edit" size="lg">
      <template #modal-title> Editar libro </template>
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
            <b-col>
              <label class="mr-sm-2">Status</label>
              <b-form-select v-model="book.status">
                <b-form-select-option :value="true"
                  >Activo</b-form-select-option
                >
                <b-form-select-option :value="false"
                  >Inactivo</b-form-select-option
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
            @click="Save(book.id)"
          >
            Guardar
          </b-button>
          <b-button
            variant="default"
            size="sm"
            class="float-right"
            @click="showModalEdit = false"
          >
            Cerrar
          </b-button>
        </div>
      </template>
    </b-modal>
  </div>
</template>

<script>
import swal from "sweetalert";

export default {
  props: ["EntityId"],
  layout: "default",
  data() {
    return {
      showModalEdit: false,
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
    getBook(id) {
      this.$axios
        .get(`/Book/${id}`)
        .then((result) => {
          this.book = result.data;
        });
    },

    getEditorial() {
      this.$axios
        .get("/Editorial")
        .then((result) => {
          this.editorial = result.data.$values;
        });
    },

    Save(id) {
      this.$axios
        .put(`/Book/${id}`, this.book)
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
  watch: {
    EntityId(newValue, oldValue) {
      this.getBook(newValue);
    },
  },
  created() {
    this.getEditorial();
  },
};
</script>

<style></style>
