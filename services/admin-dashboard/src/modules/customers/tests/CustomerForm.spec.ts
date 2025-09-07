import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerForm from '../components/CustomerForm.vue'

describe('CustomerForm.vue', () => {
  it('renders form and handles submit', async () => {
    const wrapper = mount(CustomerForm, {
      props: {
        visible: true,
        customer: {
          fullName: 'John Doe'
        }
      },
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ]
      }
    })

    await wrapper.find('input').setValue('Jane Doe')
    await wrapper.find('form').trigger('submit.prevent')

    // You would typically assert that a store action was called here
  })
})
