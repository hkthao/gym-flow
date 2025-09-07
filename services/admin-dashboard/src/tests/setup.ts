import { config } from '@vue/test-utils'

config.global.stubs = {
  'el-input': {
    template: '<input v-bind="$attrs" />'
  },
  'el-table': {
    template: '<div><slot /></div>'
  },
  'el-table-column': {
    template: '<div><slot /></div>'
  }
}
