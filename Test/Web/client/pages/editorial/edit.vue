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
                v-model="editorial.description"
              ></b-form-input>
            </b-col>
            <b-col>
              <label class="mr-sm-2">Status</label>
              <b-form-select v-model="editorial.status">
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
            @click="Save(editorial.id)"
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
      editorial: {
        description: "",
        status: true,
      },
      editorial: [{}],
    };
  },
  methods: {
    getById(id) {
      this.$axios
        .get(`/Editorial/${id}`)
        .then((result) => {
          this.editorial = result.data;
        });
    },

    Save(id) {
      this.$axios
        .put(`/Editorial/${id}`,
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
  watch: {
    EntityId(newValue, oldValue) {
      this.getById(newValue);
    },
  },
};
</script>

<style></style>
