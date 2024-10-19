<script setup lang="ts">
import { onMounted } from 'vue';
import { computed, ref } from "vue"
import fetchToHttp from "../services/fetchToHttp"
import { getExample } from "../services/getExample"
// import HtmlPreCode from "../components/HtmlPreCode.vue"
import HttpPreCode from "./HttpPreCode.vue"

function formatJson(json: any): string {
  if (typeof json !== 'object' && typeof json !== 'undefined' && json !== null) {
    return '{}'
  }

  try {
    return JSON.stringify(json ?? {}, null, 2)
  } catch {
    return '{}'
  }
}


const props = defineProps({
  operationId: {
    type: String,
    required: true,
  },
  baseUrl: {
    type: String,
    required: true,
  },
  path: {
    type: String,
    required: true,
  },
  method: {
    type: String,
    required: true,
  },
  isDark: {
    type: Boolean,
    required: true,
  },
  hideEndpoint: {
    type: Boolean,
    default: false,
  },
  parameters: {
    type: Object,
    required: false,
  },
  schema: {
    type: Object,
    required: false,
  },
  securitySchemes: {
    type: Object,
    required: true,
  },
})

onMounted(() => {
  console.log(props.parameters)
})

const request = ref({
  url: `${props.baseUrl}${props.path}`,
  headers: {},
})

const queryParams = computed(() => {
  if (!props.parameters)
    return []
  
  return props.parameters.filter(parameter => parameter && parameter.in === 'query')
})

const query = computed(() => {
  // console.log("queryParams.value", queryParams.value)
  if (queryParams.value.length === 0)
    return ""

  let q = "\n?"
  for (let i = 0; i<queryParams.value.length; i++) {
    const qu = queryParams.value[i]
    const ex = getExample(qu)
    q = `${q}${qu.name}=${ex}\n&`
  }

  return q.substring(0, q.length - 2)
})

const curl = computed(() => {
  const headers = request.value.headers
  if (!headers?.['Content-Type']) {
    headers['Content-Type'] = 'application/json'
  }

  
  return fetchToHttp({
    method: props.method.toUpperCase(),
    url: request.value.url + query.value,
    headers,
    body: request.value.body ? formatJson(request.value.body) : null,
  })
})
</script>

<template>
  <div class="flex flex-col space-y-2">
    <HttpPreCode :code="curl" :is-dark="isDark" />
  </div>
</template>
