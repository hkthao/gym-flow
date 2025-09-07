import { describe, it, expect, vi } from 'vitest'
import { mount } from '@vue/test-utils'
import { createTestingPinia } from '@pinia/testing'
import CustomerForm from '../components/CustomerForm.vue'

describe('CustomerForm.vue', () => {
  const mountComponent = (props = {}) => {
    return mount(CustomerForm, {
      global: {
        plugins: [
          createTestingPinia({
            createSpy: vi.fn
          })
        ]
      },
      props: {
        visible: true,
        customer: null,
        ...props
      }
    })
  }

  it('renders form with empty data for a new customer', () => {
    const wrapper = mountComponent({ customer: {} })
    const textField = wrapper.findComponent({ name: 'VTextField' })
    expect(textField.props('modelValue')).toBeUndefined()
  })

  it('renders form with data for an existing customer', () => {
    const customer = { id: 1, fullName: 'Test User' }
    const wrapper = mountComponent({ customer })
    const textField = wrapper.findComponent({ name: 'VTextField' })
    expect(textField.props('modelValue')).toBe('Test User')
  })

  it('emits update:visible when cancel button is clicked', async () => {
    const wrapper = mountComponent()
    const buttons = wrapper.findAllComponents({ name: 'VBtn' })
    const cancelButton = buttons.find(btn => btn.text() === 'Cancel')
    await cancelButton.trigger('click')
    
    expect(wrapper.emitted('update:visible')).toBeTruthy()
    expect(wrapper.emitted('update:visible')[0][0]).toBe(false)
  })

  it('emits update:visible when confirm button is clicked', async () => {
    const wrapper = mountComponent()
    const buttons = wrapper.findAllComponents({ name: 'VBtn' })
    const confirmButton = buttons.find(btn => btn.text() === 'Confirm')
    await confirmButton.trigger('click')
    
    expect(wrapper.emitted('update:visible')).toBeTruthy()
    expect(wrapper.emitted('update:visible')[0][0]).toBe(false)
  })
})